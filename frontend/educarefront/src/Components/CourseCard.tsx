import {Box, Card, CardContent, Typography} from "@mui/material";
import heartblack from '../Assets/images/heart-black.png'
import heartred from '../Assets/images/heart-red.png'
import {useEffect, useState} from "react";
import {Link} from "react-router-dom"
interface Props {
    courseAbbreviation: string;
    universityName: string;
    fieldName: string;
    degreeAbbreviation: string;
    year: string;
    isFavourite: boolean;
    id:string;
}

export function CourseCard(props: Props) {

    const {courseAbbreviation, fieldName, universityName, year, degreeAbbreviation, isFavourite,id} = props;
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
                      <Link to={`/Course/:${id}`}  style={{textDecoration:'none',color:'black'}}>{courseAbbreviation}</Link>
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