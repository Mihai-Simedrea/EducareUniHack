import * as React from 'react';
import "./LabelBottomNavigation.css"
import {HiHome} from "react-icons/hi"
import {HiSearch} from "react-icons/hi"
import {FaHeart} from "react-icons/fa"
import {FaUser} from "react-icons/fa"
interface Props{
  icon:number
}
export default function LabelBottomNavigation(props: Props) {
  const {icon} = props
  return (
    <div className='navbar'>
      <h1><HiHome color={icon === 1 ? "#66bb6a":"#070707"}></HiHome></h1>
      <h1><HiSearch color={icon === 2 ? "#66bb6a":"#070707"}></HiSearch></h1>
      <h1><FaHeart color={icon === 3 ? "#66bb6a":"#070707"}></FaHeart></h1>
      <h1><FaUser color={icon === 4 ? "#66bb6a":"#070707"}></FaUser></h1>
    </div>
  );
}