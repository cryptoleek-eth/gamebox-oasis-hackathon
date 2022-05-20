import styled from "styled-components";
import { IconButton, Button } from "@mui/material";

export const StyledIconButton = styled(IconButton)(({ theme }) => ({
    display: "flex",
    alignItems: "center",
    justifyContent: "space-between",
    color: theme.palette.primary.main,

    [theme.breakpoints.up("md")]: {
        display: "none"
    },
}))

export const StyledButton = styled(Button)(({ theme }) => ({
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
    color: theme.palette.secondary.dark,
    backgroundColor: theme.palette.primary.main,

    ":hover": {
        border: `2px solid ${theme.palette.primary.main}`,
        backgroundColor: "transparent",
        color: theme.palette.secondary.light,
        margin: "0px",
    }

}))