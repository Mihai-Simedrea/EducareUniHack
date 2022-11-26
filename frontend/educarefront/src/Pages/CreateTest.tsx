import React, { useState } from 'react'
import { SearchBar } from '../Components/SearchBar'
import LabelBottomNavigation from '../Components/LabelBottomNavigation';
import { SimpleHeader } from '../Components/SimpleHeader';
import { positions } from '@mui/system';
interface Props{
  name:string
}
export const CreateTest = (props: Props) => {
    const {name} = props;
    const [inputText, setInputText] = useState('');
  return (
    <div>
        <SimpleHeader text='{name}'></SimpleHeader>
        <form>
          <input type="submit" style={{
            border:"none",
            borderRadius:"10px",
            padding:"5px 10px",
            background:"#66bb6a",
            position:"fixed",
            bottom:"130px",
            left:"100px"
          }}>Start Test</input>
        </form>
        <LabelBottomNavigation icon={3}></LabelBottomNavigation>
    </div>
  )
}
