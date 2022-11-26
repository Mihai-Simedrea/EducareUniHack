import React, { useState } from 'react'
import { SearchBar } from '../Components/SearchBar'
import LabelBottomNavigation from '../Components/LabelBottomNavigation';
export const Favorite = () => {
    const [inputText, setInputText] = useState('');
  return (
    <div>
        <SearchBar searchedText={inputText} setSearchedText={setInputText}></SearchBar>
        <LabelBottomNavigation icon={3}></LabelBottomNavigation>
    </div>
  )
}
