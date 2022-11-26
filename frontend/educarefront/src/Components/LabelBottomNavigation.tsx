import * as React from 'react';
import "./LabelBottomNavigation.css"
import {HiHome} from "react-icons/hi"
import {HiSearch} from "react-icons/hi"
import {FaHeart} from "react-icons/fa"
import {FaUser} from "react-icons/fa"

export default function LabelBottomNavigation() {
  return (
    <div className='navbar'>
      <h1><HiHome></HiHome></h1>
      <h1><HiSearch></HiSearch></h1>
      <h1><FaHeart></FaHeart></h1>
      <h1><FaUser></FaUser></h1>
    </div>
  );
}