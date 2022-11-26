import React, { useState } from 'react'
import "./CardExercises.css"
interface Props{
    title: string;
    username: string;
    date: string;
}
export default function CardExercises(props: Props) {
    const {title, username, date} = props; 
    return (
    <div className='card-exercises'>
        <h4>{title}</h4>
        <div className='card-exercises-down'>
            <div className='card-exercises-text'>
                <p>Postat de {username}</p>
                <p>{date}</p>
            </div>
            <button className='btn-rezolva'>Rezolva</button>
        </div>
      </div>
    );
  }