import React, { useEffect, useState } from 'react'
import { SearchBar } from '../Components/SearchBar'
import LabelBottomNavigation from '../Components/LabelBottomNavigation';
import PlusButton from  "../Components/PlusButton"
import { ApiClient } from '../api';
const Universitati = () => {
    const userback=new ApiClient();
    const [inputText, setInputText] = useState('');
    
  return (
    <div>
        <SearchBar searchedText={inputText} setSearchedText={setInputText}></SearchBar>
        <PlusButton></PlusButton>
        <LabelBottomNavigation icon={2}></LabelBottomNavigation>
    </div>
  )
}

export default Universitati