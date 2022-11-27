import { useParams } from "react-router-dom";
import { SearchBar } from "../Components/SearchBar";
import LabelBottomNavigation from "../Components/LabelBottomNavigation";
import { useState,useEffect } from "react";
import HandleCourses from "../endpoints/HandleCourses";
import {Link} from "react-router-dom";
import {Box, Card, CardContent, Typography} from "@mui/material";
import heartblack from '../Assets/images/heart-black.png'
import heartred from '../Assets/images/heart-red.png'
type Specialization={
    id:string;
    name:string;
}

const PageWithSpecilization=()=>{
 const {spid}=useParams();
const coursesback=HandleCourses();
const [list,setList]=useState<Specialization[]>();
const [inputText,setInputText]=useState<string>('');
const  request=async()=>{
    return await fetch(`https://educare-hackathon.azurewebsites.net/api/Field/${spid}`,{
                 method:"GET",
                 headers:{
                    "Content-Type":"application/json"
                 }
    })
}
const getData=async()=>{
    const res=await request();
    const resvalue=await res.json();
    console.log(resvalue);
    setList(resvalue);
}
useEffect(()=>{
    getData();
},[])

    const styles = {
        container: {
            borderRadius: "30px",
            width: "352px",
            boxShadow: '0px 0px 20px #7C7C7C'
        },
        textTitle: {
            fontSize: 24,
            //textAlign: "left",
            lineHeight: "24px",
            //marginBottom: "12px",
            //justifyContent: "center",
        },
        text: {
            fontSize: 12,
            textAlign: "left",
        }
    };
        let [click, setClick] = useState(0);

return(
    <div>
      <SearchBar searchBy={"Field"} searchedText={inputText} setSearchedText={setInputText}></SearchBar>
         <Box>
              <Box sx={{width:'350px',height:"100%",display:"flex",flexDirection:'column',justifyContent:'flex-start',alignItems:'center',marginTop:'150px',gap:'20px'}}>
                {
                    list?.map((e)=>(
                          <Card sx={styles.container}>
            <CardContent>
                <Box sx={{
                    justifyContent: "space-between",
                    alignItems: "center",
                    display: 'flex',
                    flexDirection: 'row',
                    marginBottom: "12px",
                }}>
                
                    <Typography sx={styles.textTitle}>
                      <Link to={`/Degree/${e.id}`}style={{textDecoration:'none',color:'black'}} >{e.name}</Link> 
                    </Typography>
                    
                        </Box>
                        </CardContent>
                        </Card>
                       

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

export default PageWithSpecilization;