import {Box, Card, CardContent, Typography} from "@mui/material";
import heartblack from '../Assets/Images/heart-black.png'
import heartred from '../Assets/Images/heart-red.png'
import {useEffect, useState} from "react";

interface Props {
    courseAbbreviation: string;
    universityName: string;
    fieldName: string;
    degreeAbbreviation: string;
    year: number;
    onHeartPress: () => void;
    isFavourite: boolean;
}

export function CourseCard(props: Props) {
    const {courseAbbreviation, fieldName, universityName, year, degreeAbbreviation, onHeartPress, isFavourite} = props;
    const styles = {
        container: {
            borderRadius: "30px",
            width: "352px",
            boxShadow: '0px 0px 20px #7C7C7C'
        },
        textTitle: {
            fontSize: 24,
            //textAlign: "left",
            lineHeight: "24px",
            //marginBottom: "12px",
            //justifyContent: "center",
        },
        text: {
            fontSize: 12,
            textAlign: "left",
        }
    };
    let [click, setClick] = useState(0);
    const [favourite, setFavourite] = useState(isFavourite);

    useEffect(() => {
        if (click != 0) {
            onHeartPress()
        }
    }, [favourite]);

    return (
        <Card sx={styles.container}>
            <CardContent>
                <Box sx={{
                    justifyContent: "space-between",
                    alignItems: "center",
                    display: 'flex',
                    flexDirection: 'row',
                    marginBottom: "12px",
                }}>
                    <Typography sx={styles.textTitle}>
                        {courseAbbreviation}
                    </Typography>

                    {favourite ?
                        <img src={heartred} height="20px" width="20px" onClick={() => {
                            setFavourite(!favourite);
                            setClick(++click)
                        }}></img> :
                            <img src={heartblack} height="20px" width="20px"
                            onClick={() => {
                            setFavourite(!favourite);
                            setClick(++click);

                        }}></img>}
                        </Box>

                        <Typography sx={styles.text}>
                    {universityName}
                        </Typography>

                        <Typography sx={styles.text}>
                    {fieldName}
                        </Typography>

                        <Typography sx={styles.text}>
                    {degreeAbbreviation} AN {year}
                        </Typography>


                        </CardContent>
                        </Card>
                        )
                        }