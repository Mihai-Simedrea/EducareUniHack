const useLocal=()=>{
    return{
         createLocalEntry(key:string,value:string){
            sessionStorage.setItem(key,value);
        },
        getLocalEntry(key:string):string|null{
            return sessionStorage.getItem(key);
        }

    }
}

export default useLocal;