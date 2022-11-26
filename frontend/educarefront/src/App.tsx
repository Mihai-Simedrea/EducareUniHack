import React from 'react';
import logo from './logo.svg';
import './App.css';
import LabelBottomNavigation from './Components/LabelBottomNavigation';
import CardMaterials from './Components/CardMaterials';
import DropdownList from './Components/DropdownList';
import CardExercises from './Components/CardExercises';
import PlusButton from "./Components/PlusButton"

function App() {
  return (
    <>
    <DropdownList subject='Relatia de mostenire'></DropdownList>
    <CardMaterials title={"Definitii si Teoreme"} username={"Kaarl"} date={"23-10-2022"} likes={56} dislikes={8} isLiked={true} isDisliked={false}></CardMaterials>
    <CardExercises title={"Exercitii din culegere"} username="Kaarl" date='23-10-2022' ></CardExercises>
    <PlusButton></PlusButton>
    </>
    );
}

export default App;
