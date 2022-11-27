import { useParams } from "react-router-dom";
import HandleUniversity from "../endpoints/HandleUniversity";
import LabelBottomNavigation from "../Components/LabelBottomNavigation";
import {useState,useEffect} from "react"
import {Box} from "@mui/material"
import UniversityOrFieldCard from "../Components/UniversityOrFieldCard";
import { SearchBar } from "../Components/SearchBar";
type fieldsUni={
    faculties:{
        name:string;
        fields:{}[]
        id:string;
    }[],
   
 
}
const PageWithField=()=>{
const {unid}=useParams();
const uniback=HandleUniversity();
const [list,setList]=useState<fieldsUni>();
const [inputText,setInputText]=useState<string>('');

const getFields=async()=>{
    const res=await uniback.GetUniversityById(unid);
    const data=await res.json();
    setList(data);
}
useEffect(()=>{
    getFields();
},[]);
return(
    <div>
         <SearchBar searchBy={"Field"} searchedText={inputText} setSearchedText={setInputText}></SearchBar>
         
         <Box>
              <Box sx={{width:'350px',height:"100%",display:"flex",flexDirection:'column',justifyContent:'flex-start',alignItems:'center',marginTop:'150px',gap:'20px'}}>
                {
                    list?.faculties.map((e)=>(
                        <UniversityOrFieldCard
                        universityOrFieldName={e.name}
                        nrOfMaterialsUploaded="100"
                        nrOfExercises="120"
                        isUniversity={false}
                        id={e.id}/>
                    ))  }


              </Box>
              <Box
              sx={{height:'122px'}}
              ></Box>

         </Box>

        <LabelBottomNavigation icon={2}></LabelBottomNavigation>
    </div>

)


}

export default PageWithField;