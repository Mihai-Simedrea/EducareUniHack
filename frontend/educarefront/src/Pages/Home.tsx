import  { useEffect, useState } from 'react'
import { SearchBar } from '../Components/SearchBar'
import LabelBottomNavigation from '../Components/LabelBottomNavigation';
import { SearchList } from '../Components/SearchList';
import HandleCourses from '../endpoints/HandleCourses';
import useLocal from '../CustomHooks/useLocal';
import { CourseCard } from '../Components/CourseCard';
import {Box} from "@mui/material";
import HandleFields from '../endpoints/HandleFields';
import HandleUniversity from '../endpoints/HandleUniversity';
export type HeartCard= {
    courseAbbreviation: string;
    universityName: string;
    fieldName: string;
    degreeAbbreviation: string;
    year: number;
    isFavourite: boolean;
    
}
export const Home = () => {
    const fieldback=HandleFields();
    const universitybac=HandleUniversity();
    const list:HeartCard[]=[{
       courseAbbreviation:"POO",
       universityName:"Universitate Politehnica Timisoara",
       fieldName:"AC",
       degreeAbbreviation:"CTI",
       year:2,
       isFavourite:true},
       {
       courseAbbreviation:"PCDD",
       universityName:"Universitate Politehnica  Bucuresti",
       fieldName:"AC",
       degreeAbbreviation:"IS",
       year:2,
       isFavourite:true},
       {
       courseAbbreviation:"Inteligenta Artificiala",
       universityName:"Universitate Tehnica Cluj",
       fieldName:"AC",
       degreeAbbreviation:"CTI",
       year:3,
       isFavourite:false},
       {
       courseAbbreviation:"POO",
       universityName:"Universitate Politehnica Timisoara",
       fieldName:"AC",
       degreeAbbreviation:"CTI",
       year:2,
       isFavourite:true},
       {
       courseAbbreviation:"PCDD",
       universityName:"Universitate Politehnica  Bucuresti",
       fieldName:"AC",
       degreeAbbreviation:"IS",
       year:2,
       isFavourite:true},
       {
       courseAbbreviation:"Inteligenta Artificiala",
       universityName:"Universitate Tehnica Cluj",
       fieldName:"AC",
       degreeAbbreviation:"CTI",
       year:3,
       isFavourite:false},
  ];
    const [searchList,setSearchList]=useState<HeartCard[]>()
    const [inputText, setInputText] = useState('');
    const local=useLocal();
    const uid=local.getLocalEntry('uid');
    const courseback=HandleCourses();
    // const [list,setList]=useState<HeartCard[]>();
    const handleChange=async()=>{
      if(inputText==''){
        setSearchList(list)
      }
      else{
      const data=list.filter((e)=>{
          return e.courseAbbreviation.includes(inputText)==true
        })
        setSearchList(data); }
      // setList(resvalue);
    }
    useEffect(()=>{

     handleChange(); 

    },[inputText])
  return (
    <Box sx={{width:'100%',height:'100vh'}}>
       <SearchBar searchBy={"Courses"} searchedText={inputText} setSearchedText={setInputText}></SearchBar>
        <Box sx={{width:'350px',height:"100%",display:"flex",flexDirection:'column',justifyContent:'flex-start',alignItems:'center',marginTop:'150px',gap:'20px'}}>
         {
          searchList?.map((e)=>(
            <CourseCard
            courseAbbreviation={e.courseAbbreviation}
            degreeAbbreviation={e.degreeAbbreviation}
            universityName={e.universityName}
            year={e.year}
            isFavourite={e.isFavourite}
            fieldName={e.fieldName}
            ></CourseCard>


          ))
          


         }
         <Box sx={{marginTop:'100px'}}></Box>

        </Box>        
        <LabelBottomNavigation icon={1 }></LabelBottomNavigation>
    </Box>
       
    
  )
}
