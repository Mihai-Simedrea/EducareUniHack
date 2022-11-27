import { Typography } from '@mui/material';
import { borderRadius } from '@mui/system';
import e from 'express';
import { validateHeaderName } from 'http';
import React, { useState } from 'react'
import LabelBottomNavigation from './LabelBottomNavigation';
import { SimpleHeader } from './SimpleHeader';
interface Props{
    curs:string
}
export const Blanks = (props: Props) => {
    let {curs} = props;
    const cut = (curs:string) => {
        let k = 0;
        let i;
        for(i = 0; i < curs.length; i++){
            if(curs[i] === '.'){
                k++;
            }
            if(k > 10){
                break;
            }
        }
        return curs.slice(0,i+1).split(" ");
    }
    const str  = cut(curs);
    //console.log(str)
    const cut2 = (curs:string[]) => {
        let k = 0;
        let c = 0;
        let i;
        let rand : number[] = [];
        for(i = 0; i < curs.length; i++){
            if(curs[i][curs[i].length-1] === '.'){
                rand.push(Math.floor(Math.random() * i) + k - 1);
                k = i;
            }
        }
        return rand
    }
   let rand = cut2(str);
   const [input1, setInput1] = useState("");
   const [input2, setInput2] = useState("");
   const [input3, setInput3] = useState("");
   const [input4, setInput4] = useState("");
   const [input5, setInput5] = useState("");
   const [input6, setInput6] = useState("");
   const [input7, setInput7] = useState("");
   const [input8, setInput8] = useState("");
   const [input9, setInput9] = useState("");
   const [input10, setInput10] = useState("");
   const [ids, setIds] = useState(0);
   const afisare = ()=>{
    for(let j = 1; j <= 10; j++){
        let k = 0;
        let i:number;
        for(i = k; curs[i][curs[i].length-1] === '.'; i++){
            if(rand.find(e=>e===i)){
                return  <input type={"submit"}
                style={{
                    border:"none",
                    padding:"8px 20px",
                    color:"white",
                    background:"#66bb6a",
                    position:"fixed",
                    left:"160px",
                    bottom:"150px",
                    borderRadius:"20px"
                }}></input>
            }
            else{
                return curs[i] + ""
            }
        }
        k = i+1;
    }
}
   const onChange = (e:React.FormEvent<HTMLInputElement>): void =>{
        switch(+e.currentTarget.id){
            case 1:
                setInput1(e.currentTarget.value);
                break;
            case 2:
                setInput2(e.currentTarget.value);
                break;
            case 3:
                setInput3(e.currentTarget.value);
                break;
            case 4:
                setInput4(e.currentTarget.value);
                break;
            case 5:
                setInput5(e.currentTarget.value);
                break;
            case 6:
                setInput6(e.currentTarget.value);
                break;
            case 7:
                setInput7(e.currentTarget.value);
                break;
            case 8:
                setInput8(e.currentTarget.value);
                break;
            case 9:
                setInput9(e.currentTarget.value);
                break;
            case 10:
                setInput10(e.currentTarget.value);
                break;
        }
   }
   const val = (e:React.FormEvent<HTMLInputElement>) =>{
    switch(parseInt(e.currentTarget.id)){
        case 1:
            return input1
        case 2:
            return input2
        case 3:
            return input3
        case 4:
            return input4
        case 5:
            return input5
        case 6:
            return input6
        case 7:
            return input7
        case 8:
            return input8
        case 9:
            return input9
        case 10:
            return input10
        default:
            return ""
    }
   }
  
  return (
    <>
        <SimpleHeader text='Fill the blanks'></SimpleHeader>
        
        <form>
            {afisare()}
        </form>
        <LabelBottomNavigation icon={1}></LabelBottomNavigation>
    </>
  )
}
