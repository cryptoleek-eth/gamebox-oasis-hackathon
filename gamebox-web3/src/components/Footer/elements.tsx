import styled from "styled-components";
import { Link as LinkScroll } from 'react-scroll';

export const FooterLink = styled(LinkScroll)(({ theme }) => ({
    listStyle: "none",
    transition: "0.2s ease-in-out",
    color: theme.palette.secondary.light,
    fontSize: "16px",
    textDecoration: "none",
    marginBottom: "20px",
    cursor: "pointer",

    ":hover": {
        color: theme.palette.primary.main,
    },

    [theme.breakpoints.down("md")]: {
        textAlign: "center"
    },
}))

export const FooterCopyright = styled('div')(({ theme }) => ({
    color: theme.palette.secondary.light,
    borderTop: `1px solid ${theme.palette.secondary.main}`,
    padding: "15px",
    margin: "20px auto 0",
    textAlign: "center",
    width: "30%",
    display: "block",
    [theme.breakpoints.between("md", "lg")]: {
        width: "50%"
    },

    [theme.breakpoints.down("md")]: {
        width: "80%",
    },
}))