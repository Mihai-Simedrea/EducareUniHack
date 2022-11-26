import React from 'react'
import "./SimpleHeader.css"
interface Props{
    text:string
}
export const SimpleHeader = (props: Props) => {
    const {text} = props; 
    return (
    <div className='head'>
        <h3>{text}</h3>
    </div>
  )
}
