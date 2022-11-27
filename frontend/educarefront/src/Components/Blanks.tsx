import React, { useState } from 'react'
import LabelBottomNavigation from './LabelBottomNavigation';
import { SimpleHeader } from './SimpleHeader';
interface Props{
    curs:string
}
export const Blanks = (props: Props) => {
//     let {curs} = props;
//     const cut = (curs:string) => {
//         let k = 0;
//         let i;
//         for(i = 0; i < curs.length; i++){
//             if(curs[i] === '.'){
//                 k++;
//             }
//             if(k > 10){
//                 break;
//             }
//         }
//         return curs.slice(0,i+1).split(" ");
//     }
//     const str  = cut(curs);
//     //console.log(str)
//     const cut2 = (curs:string[]) => {
//         let k = 0;
//         let c = 0;
//         let i;
//         let rand : number[] = [];
//         for(i = 0; i < curs.length; i++){
//             if(curs[i][curs[i].length-1] === '.'){
//                 rand.push(Math.floor(Math.random() * i) + k - 1);
//                 k = i;
//                 console.log(curs[i])
//             }
//         }
//         return rand
//     }
//    let rand = cut2(str);
  return (
    <>
        <SimpleHeader text='Fill the blanks'></SimpleHeader>
            {/* {str.map((word)=>{
                if(rand.find((a)=>a === str.indexOf(word))){
                  //  setIds(ids+1);
                    return <input type={"text"}
                    style={{width:`${word.length*12}px`
                    }}></input> 
                }
                else{
                    return " " + word + " "
                }
            })} */}
            {/* <button 
            style={{
                border:"none",
                padding:"8px 20px",
                color:"white",
                background:"#66bb6a",
                position:"fixed",
                left:"160px",
                bottom:"150px",
                borderRadius:"20px"
            }}></button> */}
        <LabelBottomNavigation icon={1}></LabelBottomNavigation>
    </>
  )
}
