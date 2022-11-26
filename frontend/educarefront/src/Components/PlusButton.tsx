import * as React from 'react';
import { Component } from 'react';
import {HiDocumentText} from "react-icons/hi"
import {BsPencilFill} from "react-icons/bs"
import "./PlusButton.css"

export default function CardMaterials() {
    const [plus, setPlus] = React.useState(false)
    return (
        <>
            <div className={!plus ? 'plus-btn': "plus-btn plus-btn-on"} onClick={()=>{setPlus(!plus)}}><h5>+</h5></div>
            <div className={!plus ? 'test-btn': "test-btn test-btn-on"}><HiDocumentText color='#66bb6a'/></div>
            <div className={!plus ? 'add-btn': "add-btn add-btn-on"}><BsPencilFill color='#66bb6a'/></div>
            <div className={!plus ? "" : 'btns'}>
                <div className='text-btn up'><p>Generate test</p></div>
                <div className='text-btn mid'><p>Add exercise</p></div>
                <div className='text-btn down'><p>Close</p></div>
            </div>
        </>
    )
}