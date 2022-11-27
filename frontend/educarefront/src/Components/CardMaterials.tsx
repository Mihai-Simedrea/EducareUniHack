import React, { useState } from 'react'
import {Link} from "react-router-dom"
import "./CardMaterials.css"
import  {Button}  from "@mui/material"
import {AiFillLike} from "react-icons/ai"
import {AiFillDislike} from "react-icons/ai"
interface Props{
    title: string;
    username: string;
    date: string;
    likes: number;
    dislikes: number;
    isLiked: boolean;
    isDisliked: boolean;
}
export default function CardMaterials(props: Props) {
    const {title, username, date, likes, dislikes, isLiked, isDisliked} = props; 
    const [liked, setLiked] = useState(isLiked);
    const [disliked, setDisliked] = useState(isDisliked);
    return (
    <div className='card-materials'>
        <div className='card-materials-text'>
            <h4>{title}</h4>
            <p>Postat de {username}</p>
            <p>{date}</p>
        </div>
        <div className='card-material-buttons'>
            
        <Button
              component = {Link}
            variant="contained"
            color="success"
            sx={{ width: "30%" }}
            type="submit"
            to="../Blanks"
          >
              Submit
          </Button>

            <div className='like-dis'>
                <p>{likes}</p>
                <h3 onClick={()=>{setLiked(!liked); if(disliked){setDisliked(false)}}}><AiFillLike color={liked?"#66bb6a":"#000000"} ></AiFillLike></h3>
                <p>{dislikes}</p>
                <h3 onClick={()=>{setDisliked(!disliked); if(liked){setLiked(false)}}}><AiFillDislike color={disliked?"#66bb6a":"#000000"}></AiFillDislike></h3>
            </div>
        </div>
      </div>
    );
  }