const HandleCourses=()=>{
    return{
        async GetEnrolled(uid:string|null){
         return await  fetch(`https://educare-hackathon.azurewebsites.net/api/EnrolledCourse/${uid}/enrolled`,{
                method:'GET',
                headers:{
                    "Content-type":"application/json"
                }
            })
        },
        async EnrollTocourse(uid:string|null,courseId:string){
            return await fetch(`https://educare-hackathon.azurewebsites.net/api/EnrolledCourse/${uid}/enroll/${courseId}`,{
                method:'POST',
                headers:{
                    'Content-Type':'applicatio/json'
                }
            })
        },
        async GetFavorite(uid:string|null){
         return await fetch(`https://educare-hackathon.azurewebsites.net/api/EnrolledCourse/${uid}/favorite`,{
                    method:'GET',
                    headers:{
                        'Content-Type':"application/json"
                    }})
        },
        async AddFavorite(uid:string|null,courseId:string){
            return await fetch( `https://educare-hackathon.azurewebsites.net/api/EnrolledCourse/${uid}/favorite`,{
                method:'POST',
                headers:{
                    'Content-Type':'application/json'}
            })
        },
        async GetCourseByUniversity(id:string){
            return await fetch(`https://educare-hackathon.azurewebsites.net/api/Course/${id}`,{
                method:"GET",
                headers:{
                    "Content-Type":"application/json"
                }
            })
        }
    }
}
export default HandleCourses;