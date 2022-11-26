import React, { useEffect, useState } from 'react'
import { SearchBar } from '../Components/SearchBar'
import LabelBottomNavigation from '../Components/LabelBottomNavigation';
import { UniversityClient } from '../api';
const Universitati = () => {
    const userback=new UniversityClient();
    const [inputText, setInputText] = useState('');
    const handleGetUni=async()=>{
        const obj=await userback.g 

    }
    useEffect(()=>{
  
        


    },[inputText])
  return (
    <div>
        <SearchBar searchedText={inputText} setSearchedText={setInputText}></SearchBar>

        <LabelBottomNavigation icon={2}></LabelBottomNavigation>
    </div>
  )
}

export default Universitati