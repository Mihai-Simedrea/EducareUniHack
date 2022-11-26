<<<<<<< Updated upstream
// import React, { useState } from 'react'
// import { SearchBar } from '../Components/SearchBar'
// import LabelBottomNavigation from '../Components/LabelBottomNavigation';
// export const Home = () => {
//     const [inputText, setInputText] = useState('');
//   return (
//     <div>
//         <SearchBar searchedText={inputText} setSearchedText={setInputText}></SearchBar>
//         <LabelBottomNavigation icon={1 }></LabelBottomNavigation>
//     </div>
//   )
// }
export function Home(){
    return <></>
=======
import  { useEffect, useState } from 'react'
import { SearchBar } from '../Components/SearchBar'
import LabelBottomNavigation from '../Components/LabelBottomNavigation';
import { SearchList } from '../Components/SearchList';
import HandleCourses from '../endpoints/HandleCourses';
import useLocal from '../CustomHooks/useLocal';
export const Home = () => {
    const [inputText, setInputText] = useState('');
    const local=useLocal();
    const uid=local.getLocalEntry('uid');
    const courseback=HandleCourses();
    const [list,setList]=useState();
    const handleChange=async()=>{
      const res= await courseback.GetEnrolled(uid);
    }
    useEffect(()=>{
      

    },[inputText])
  return (
    <div>
        <SearchBar searchBy={"Courses"} searchedText={inputText} setSearchedText={setInputText}></SearchBar>
        <SearchList
        searchedText={inputText}
        searchBy="Courses"
        searchList={}></SearchList>
        
        <LabelBottomNavigation icon={1 }></LabelBottomNavigation>
    </div>
  )
>>>>>>> Stashed changes
}
