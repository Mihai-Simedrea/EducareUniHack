const HandleFields=()=>{
    return{
        async GetField(id:string){
            return await fetch(`https://educare-hackathon.azurewebsites.net/api/Field/${id}`,{
                method:"GET",
                headers:{
                    'Content-Type':"application/json"
                }
            })
        }

    }

}
export default HandleFields;