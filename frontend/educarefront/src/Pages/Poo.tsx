import React from 'react'
import DropdownList from '../Components/DropdownList'
import PlusButton from "../Components/PlusButton"

export const Poo = () => {
  return (
    <div>
        <DropdownList subject='Abstractizarea'></DropdownList>
        <DropdownList subject='Clase si Obiecte'></DropdownList>
        <DropdownList subject='Relatia de mostenire'></DropdownList>
        <PlusButton></PlusButton>
    </div>
  )
}
