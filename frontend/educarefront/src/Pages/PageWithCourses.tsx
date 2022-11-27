
import { CourseCard } from "../Components/CourseCard";
import { useParams } from "react-router-dom";
import {Box} from "@mui/material"
import { SearchBar } from "../Components/SearchBar";
import LabelBottomNavigation from "../Components/LabelBottomNavigation";
import { useState,useEffect } from "react";
import HandleCourses from "../endpoints/HandleCourses";
type Course={
    id:string;
    name:string;
    year:string;
    fieldId:string;
    universityName:string;
    facultyName:string;
    fieldName:string;
}
const PageWithCourse=()=>{
const {did}=useParams();
const coursesback=HandleCourses();
const [list,setList]=useState<Course[]>();
const [inputText,setInputText]=useState<string>('');
const getdata=async()=>{
const res=await coursesback.GetCourseByField(did);
const resdata=await res.json();
console.log(resdata);
 setList(resdata);

}
useEffect(()=>{
    getdata();},[])
    return(
         <div>
         <SearchBar searchBy={"Field"} searchedText={inputText} setSearchedText={setInputText}></SearchBar>
         <Box>
              <Box sx={{width:'350px',height:"100%",display:"flex",flexDirection:'column',justifyContent:'flex-start',alignItems:'center',marginTop:'150px',gap:'20px'}}>
                {
                    list?.map((e)=>(
                        <CourseCard
                        key={e.name}
                        courseAbbreviation={e.name}
                        universityName={e.universityName}
                        isFavourite={true}
                        degreeAbbreviation={e.fieldName}
                        fieldName={e.facultyName}
                        year={e.year}/>

                    ))

                }

              </Box>
            
              <Box
              sx={{height:'122px'}}
              ></Box>

         </Box>

        <LabelBottomNavigation icon={2}></LabelBottomNavigation>
    </div>



    )


}

 export default PageWithCourse;