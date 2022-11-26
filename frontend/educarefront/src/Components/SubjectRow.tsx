import React from 'react'
import "./SubjectRow.css"
interface Props{
    name: string;
    exerciseNumber: number;
    setExerciseNumber: React.Dispatch<React.SetStateAction<number>>;
}
export const SubjectRow = (props: Props) => {
    const {name, exerciseNumber, setExerciseNumber} = props;
  return (
    <div className='row'>
        <p>{name}</p>
        <input type="number" placeholder='0'/>
    </div>
  )
}
