import axios, { AxiosError, AxiosResponse } from "axios";
import { toast } from "react-toastify";

axios.defaults.baseURL = 'https://localhost:7209/api/'


const responseBody = (response: AxiosResponse) => response.data;
//same with const
//function responseBodyFn(response: AxiosResponse){return response.data;}

//using axios interceptor

axios.interceptors.response.use(response => {
    return response;
}, (error: AxiosError) => {
    const{data, status} = error.response!;
    switch(status){
        case 400:
            if(data.errors){
                const modelStateErrors: string[] = [];
                for(const key in data.errors){
                    if(data.errors[key]){
                        modelStateErrors.push(data.errors[key])
                    }
                }
                throw modelStateErrors.flat();
            }
            toast.error(data.title)
            break;
        case 401: 
        toast.error(data.title)
            break;
            case 500: 
        toast.error(data.title)
            break;
        default:
            break;
    }
    return Promise.reject(error.response)
    })

const requests = {
    get: (url: string) => axios.get(url).then(responseBody),
    post: (url: string, body: object) => axios.post(url).then(responseBody),
    put: (url: string, body: object) => axios.put(url).then(responseBody),
    delete: (url: string) => axios.delete(url).then(responseBody)
}

const Catalog = {
    list: () => requests.get('products'),
    details : (id: number) => requests.get(`products/${id}`)
}

const TestErrors = {
    get400Error: () => requests.get('buggy/bad-request'),
    get401Error: () => requests.get('buggy/unauthorized'),
    get404Error: () => requests.get('buggy/not-found'),
    get500Error: () => requests.get('buggy/server-error'),
    getValidationError: () => requests.get('buggy/validation-error')
}


const agent = {Catalog, TestErrors}

export default agent;