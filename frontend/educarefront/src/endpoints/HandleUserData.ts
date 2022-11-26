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
        },
        async UpdateProfileData(universityName:string,fieldName:string,facultyName:string,studyYear:string,id:string|null){
              return await fetch(`https://educare-hackathon.azurewebsites.net/api/Profile/profile/${id}`,{
                method:'POST',
                headers:{
                    "Content-Type":"application/json"

                },
                body:JSON.stringify({universityName:universityName,fieldName:fieldName,facultyName:facultyName,studyYear:studyYear})
              });
        },
        async GetProfile(id:string|null){
            return await fetch(`https://educare-hackathon.azurewebsites.net/api/profile/${id}`,{
                method:'GET',
                headers:{
                    "Content-Type":"application/json"
                },

            })
        }
}

}

export default HandleUserData;