


const HandleUserData=()=>{

    return{
        async Login(email:string,password:string){
          return await  fetch("https://educare-hackathon.azurewebsites.net/api/Users/login",{
                method:"POST",
                headers:{
                    "Content-Type":"application/json",

                },
                body:JSON.stringify({email:email,password:password})
            })
        },
        async Register(email:string,password:string,username:string){
            return await fetch("https://educare-hackathon.azurewebsites.net/api/Users/register",{
                method:"POST",
                headers:{
                    "Content-Type":"application/json"
                },
                body:JSON.stringify({email:email,password:password,username:username})
            })
        }
}

}

export default HandleUserData;