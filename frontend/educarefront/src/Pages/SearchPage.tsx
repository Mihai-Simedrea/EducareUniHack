import {SearchBar} from "../Components/SearchBar";
import {useEffect, useState} from "react";
import {SearchList} from "../Components/SearchList";
import {Box} from "@mui/material";
import HandleUniversity from "../endpoints/HandleUniversity";
import LabelBottomNavigation from "../Components/LabelBottomNavigation";

export type UniversityOrField = {
    name: string,
    totalMaterials: string,
    totalExercices: string,
    totalFields?: string,
    totalSubjects: string,
    id: string;
};


export function SearchPage() {
    const [inputText, setInputText] = useState("");
    const [list, setList] = useState<UniversityOrField[]>();
    const unibackend = HandleUniversity();
    const [condition, setCondition] = useState(false);

    async function uniHandler() {
        const res = await unibackend.UniversityByName(inputText);
        const result = await res.json();
        if(result!=null){
            setCondition(true);
            setList(result);
            console.log(list);
        }

    }

    useEffect(() => {
        if (inputText !== '')
            uniHandler();
        console.log(list);
    }, [inputText]);

    const styles = {
        container: {
            flexDirection: "column",
            display: "flex",
            alignItems: "center",
            justifyContent: "center",
        }
    };

    console.log(list);
    //@ts-ignore


    return (
        <Box sx={styles.container}>
            <SearchBar
                searchedText={inputText}
                setSearchedText={setInputText}
                searchBy={"University"}/>
            condition && <SearchList
                //@ts-ignore
                list={list}
                searchedText={inputText}
                searchBy={"University"}
            />
            <LabelBottomNavigation icon={2}/>

        </Box>
    )
}