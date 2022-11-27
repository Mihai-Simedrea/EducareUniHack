import {Card, CardContent, Typography} from "@mui/material";
import  {Link} from "react-router-dom"
interface Props {
    universityOrFieldName: string;
    nrOfFields?: string;
    nrOfMaterialsUploaded: string;
    nrOfExercises: string;
    isUniversity: boolean;
    id:string;
}

export default function UniversityOrFieldCard(props: Props) {
    const {universityOrFieldName, nrOfFields, nrOfMaterialsUploaded, nrOfExercises, isUniversity, id} = props;

    const styles = {
        container: {
            borderRadius: "30px",
            width: 352,
            boxShadow: '0px 0px 20px #7C7C7C',
            margin: "16px 0",
        },
        textTitle: {
            fontSize: 24,
            textAlign: "left",
            lineHeight: "24px",
            marginBottom: "12px"
        },
        text: {
            fontSize: 12,
            textAlign: "left",
        }
    }

    return (
        <Card sx={styles.container}>
            <CardContent key={id}>
                <Typography sx={styles.textTitle}>
                    {isUniversity ?
                        <Link to={`/University/${id}`}
                              style={{textDecoration: "none", color: "black"}}> {universityOrFieldName}</Link>
                        : <Link to={`/Field/${id}`}
                                style={{textDecoration: "none", color: "black"}}> {universityOrFieldName}</Link>
                    }

                </Typography>

                {isUniversity &&
                    <Typography sx={styles.text}>
                        {nrOfFields} specializari
                    </Typography>}

                <Typography sx={styles.text}>
                    {nrOfMaterialsUploaded} materiale
                </Typography>

                <Typography sx={{fontSize: 12, textAlign: "left"}}>
                    {nrOfExercises} exercitii
                </Typography>
            </CardContent>
        </Card>

    )
}
