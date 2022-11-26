import React, { useState } from 'react'
import { SearchBar } from '../Components/SearchBar'
import LabelBottomNavigation from '../Components/LabelBottomNavigation';
export const Home = () => {
    const [inputText, setInputText] = useState('');
  return (
    <div>
        <SearchBar searchedText={inputText} setSearchedText={setInputText}></SearchBar>
        <LabelBottomNavigation icon={1 }></LabelBottomNavigation>
    </div>
  )
}
