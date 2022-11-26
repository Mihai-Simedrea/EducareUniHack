import * as React from 'react';
import { useState } from 'react';
import "./DropdownList.css"
import {BiChevronDown} from "react-icons/bi"
import CardMaterials from "./CardMaterials"
interface Props{
    subject: string;
}
export default function DropdownList(props:Props) {
  const {subject} = props;
  const [list, setList] = useState(false);
  return (
    <div className='dropdown'>
      <div className='head'>
        <h2>{subject}</h2>
        <h2 onClick={()=>{setList(!list)}}><BiChevronDown color='#66bb6a'></BiChevronDown></h2>
      </div>
      {!list&&<p>34 materiale</p>}
      {list&&<div className='list'>
      <CardMaterials title={"Definitii si Teoreme"} username={"Kaarl"} date={"23-10-2022"} likes={56} dislikes={8} isLiked={true} isDisliked={false}></CardMaterials>
      <CardMaterials title={"Definitii si Teoreme"} username={"Kaarl"} date={"23-10-2022"} likes={56} dislikes={8} isLiked={true} isDisliked={false}></CardMaterials>
      <CardMaterials title={"Definitii si Teoreme"} username={"Kaarl"} date={"23-10-2022"} likes={56} dislikes={8} isLiked={true} isDisliked={false}></CardMaterials>
      </div>
      }
    </div>
  );
}