import React, { useState } from 'react'
import { SearchBar } from '../Components/SearchBar'
import LabelBottomNavigation from '../Components/LabelBottomNavigation';
export const Favorite = () => {
    const [inputText, setInputText] = useState('');
  return (
    <div>
        <LabelBottomNavigation icon={3}></LabelBottomNavigation>
    </div>
  )
}
