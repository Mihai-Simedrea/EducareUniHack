import {Box, Button, Typography} from "@mui/material";
import {useEffect, useState} from "react";
import heartred from "../Assets/images/heart-red.png";
import heartblack from "../Assets/images/heart-black.png";

interface Props {
    courseAbbreviation: string;
    onEnrollButtonPress: () => void;
    isFavourite: boolean;
    onHeartPress: () => void;
    exercisesSelected: boolean;
}

export function CourseHeader(props: Props) {
    const {isFavourite, courseAbbreviation, onEnrollButtonPress, onHeartPress, exercisesSelected} = props;
    const styles = {
            container2: {
                boxShadow: '0px 0px 10px #7C7C7C',
                borderBottomRightRadius: "20px",
                borderBottomLeftRadius: "20px",
                //backgroundColor: "violet",
                width: "100vw",

            },
            container: {
                //height: 128,
                paddingTop: "40px",
                // boxShadow: '0px 0px 10px #7C7C7C',
                // borderBottomRightRadius: "20px",
                // borderBottomLeftRadius: "20px",
                justifyContent: "space-evenly",
                //flexDirection: "row",
                alignItems: "center",
                display: "flex",
            },
            enrollButton: {
                width: "80px",
                borderRadius: "30px",
                marginRight: "24px",

            },
            materialsorExecisesButton: {

                //width: "80px",
                borderRadius: "30px",
                //marginRight: "24px",
            },
            matsButton: {
                flex: 1,
                borderBottomLeftRadius: "20px",

            },
            exerButton: {
                flex: 1,
                borderBottomRightRadius: "20px",
            },
        }
    ;

    let [click, setClick] = useState(0);
    const [favourite, setFavourite] = useState(isFavourite);

    useEffect(() => {
        if (click != 0) {
            onHeartPress()
        }
    }, [favourite]);
    const colorOfMatButton: "success" | "inherit" = exercisesSelected ? "inherit" : "success";
    const colorOfExerButton: "success" | "inherit" = exercisesSelected ? "success" : "inherit";
    const variantOfMat: "contained" | "outlined" = exercisesSelected?"outlined":"contained";
    const variantOfExer: "contained" | "outlined" = exercisesSelected?"contained":"outlined";


    return (
        <Box sx={styles.container2}>
            <Box sx={styles.container}>
                <Typography color={"black"} fontSize={"32px"}>{courseAbbreviation}</Typography>
                <Box sx={{display: "flex",justifyContent: "space-between", alignItems: "center"}}>
                    <Button variant="contained" color="success" sx={styles.enrollButton}
                            onClick={onEnrollButtonPress}>Enroll</Button>
                    {favourite ?
                        <img
                            src={heartred}
                            height="20px"
                            width="20px"
                            onClick={() => {
                                setFavourite(!favourite);
                                setClick(++click)
                            }}></img> :
                        <img
                            src={heartblack}
                            height="20px"
                            width="20px"
                            onClick={() => {
                                setFavourite(!favourite);
                                setClick(++click);
                            }}></img>}
                </Box>
            </Box>
            <Box sx={{display: "flex", flex: 1, color: "black"}}>
                <Button
                    variant={variantOfMat}
                    color={colorOfMatButton}
                    sx={styles.matsButton}
                    onClick={onEnrollButtonPress}
                >Materiale</Button>

                <Button
                    variant={variantOfExer}
                    color={colorOfExerButton}
                    sx={styles.exerButton}
                    onClick={onEnrollButtonPress}>Exercitii</Button>
            </Box>
        </Box>
    )
}