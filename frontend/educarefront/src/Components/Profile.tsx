import { Box, Avatar, Typography, Button } from "@mui/material";
import { useState, useEffect } from "react";
import useLocal from "../CustomHooks/useLocal";
import { useNavigate, useParams } from "react-router-dom";
const Profile = () => {
  const { emailrouter } = useParams();
  const navigate = useNavigate();
  const [university, setUniversity] = useState<string | null>(" ");
  const [field, setField] = useState<string | null>(" ");
  const [degree, setDegree] = useState<string | null>(" ");
  let email: string;
  const [buttonView, setButtonView] = useState<string | null>(" ");
  const [contentLike, setContentLike] = useState<string | null>(" ");
  const [posts, setPosts] = useState<string | null>(" ");
  const local = useLocal();

  useEffect(() => {
    console.log(emailrouter);
    if (local.getLocalEntry("university") != null) {
      if (emailrouter == local.getLocalEntry("email")) {
        setUniversity(local.getLocalEntry("university"));
        setDegree(local.getLocalEntry("degree"));
        setField(local.getLocalEntry("field"));
        setPosts(local.getLocalEntry("posts"));
        setContentLike(local.getLocalEntry("like"));
      }
      else{
        setButtonView('none');
      }
    }
  }, []);

  return (
    <Box
      sx={{
        width: "100%",
        height: "100%",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
      }}
    >
      <Box
        sx={{
          width: "400px",
          height: "500px",
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          justifyContent: "center",
          boxShadow: "10",
          borderRadius:'30px'
        }}
      >
        <Avatar
          sx={{ width: "10rem", height: "10rem" }}
          src={require("../Assets/images/profile.jpg")}
        ></Avatar>
        <Box
          sx={{
            width: "70%",
            height: "10rem",
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            justifyContent: "center",
          }}
        >
          <Typography variant="subtitle1">{university}</Typography>
          <Typography variant="subtitle1">{field}</Typography>
          <Typography variant="subtitle1">{degree}</Typography>
          <Typography>Likes Recevide: {contentLike}</Typography>
          <Typography>Posts Uploaded: {posts}</Typography>
        </Box>
        <Box
          sx={{
            width: "70%",
            height: "fit-content",
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            justifyContent: "center",
            gap: "4px",
          }}
        >
          <Button
            variant="contained"
            sx={{ width: "9rem", display: buttonView }}
            onClick={() => {
              navigate("/AccountData");
            }}
            color="success"
          >
            Edit Profile
          </Button>
          <Button
            variant="contained"
            sx={{ width: "9rem", display: buttonView }}
            color="success"
          >
            Log Out
          </Button>
        </Box>
      </Box>
    </Box>
  );
};
export default Profile;
