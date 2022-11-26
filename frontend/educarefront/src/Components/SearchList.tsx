import HandleUniversity from "../endpoints/HandleUniversity";
import {useEffect} from "react";
import UniversityOrFieldCard from "./UniversityOrFieldCard";
import {UniversityOrField} from "../Pages/SearchPage";
import {Box} from "@mui/material";


interface Props {
    searchedText: string;
    searchBy: "University" | "Field" | "Courses";
    list: UniversityOrField[];
}

export function SearchList(props: Props) {
    const {searchedText, searchBy, list} = props;

    if (searchedText === "")
        return <></>

    const styles = {
        container: {
            marginTop: "136px",
        },
    }



    return (
        <Box sx={styles.container}>
            {
                list?.map((element, index) => {
                    //console.log(element.id)
                    return  <UniversityOrFieldCard
                        key={index}
                        universityOrFieldName={element.name}
                        nrOfMaterialsUploaded={element.totalSubjects}
                        nrOfExercises={element.totalExercices}
                        nrOfFields={element.totalFields}
                        isUniversity={searchBy === "University"}
                        id={element.id}
                    />
                })
            }
        </Box>
    )
    // console.log(list);
    // return <></>
}