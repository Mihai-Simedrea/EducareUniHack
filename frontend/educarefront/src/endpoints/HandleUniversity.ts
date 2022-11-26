const HandleUniversity = () => {
  return {
    async UniversityByName(name: string) {
      return await fetch(
        `https://educare-hackathon.azurewebsites.net/api/University/get-all-universities-by-name/${name}`,
        {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
    },
  };
};

export default HandleUniversity;
