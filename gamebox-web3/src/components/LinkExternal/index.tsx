import styled from "styled-components";

export const StyledTextLink = styled('a')(({ theme }) => ({
    color: theme.palette.secondary.light,
    fontSize: "16px",
    textDecoration: "none",
    marginBottom: "20px",

    ":hover": {
        color: theme.palette.primary.main,
    },

    [theme.breakpoints.down("md")]: {
        textAlign: "center",
    },
}))