import {Card, CardContent, Typography} from "@mui/material";

interface Props {
    universityOrFieldName: string;
    nrOfFields?: number;
    nrOfMaterialsUploaded: number;
    nrOfExercises: number;
    isUniversity: boolean;
}

export default function UniversityOrFieldCard(props: Props) {
    const {universityOrFieldName, nrOfFields, nrOfMaterialsUploaded, nrOfExercises, isUniversity} = props;

    const styles = {
        container: {
            borderRadius: "30px",
            width: 352,
            boxShadow: '0px 0px 20px #7C7C7C'
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
            <CardContent>
                <Typography sx={styles.textTitle}>
                    {universityOrFieldName}
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
