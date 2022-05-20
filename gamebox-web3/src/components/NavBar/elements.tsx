import styled from "styled-components";
import { AppBar } from "@mui/material";
import Toolbar from '@mui/material/Toolbar';
import { Link as LinkScroll } from 'react-scroll';

export const StyledAppBar = styled(AppBar)({
    top: 0,
    right: 0,
    left: 0,
    zIndex: 1030,
    boxShadow: "none",
    background: "transparent",
    position: "fixed",
    backgroundColor: "#242021",
})

export const StyledToolbar = styled(Toolbar)(({ theme }) => ({
    display: 'flex',
    alignItems: "center",
    justifyContent: "space-between",
    height: "70px",
    margin: "0 auto",
    width: "80%",

    [theme.breakpoints.between("md", "lg")]: {
        flexDirection: "column",
        justifyContent: "center",
        height: "100px",
    },

    [theme.breakpoints.down("md")]: {
        width: "95%",
    },
}))

export const ImgContainer = styled(LinkScroll)({
    display: "flex",
    alignItems: "center",
    cursor: "pointer",
})

export const StyledLogo = styled('img')(({ theme }) => ({
    display: "block",
    width: "100%",
    height: "70px",

    [theme.breakpoints.down("md")]: {
        width: "80%",
        height: "auto",
    },
}))

export const NavMenu = styled('ul')(({ theme }) => ({
    display: "none",

    [theme.breakpoints.between("md", "lg")]: {
        display: "flex",
        alignItems: "center",
        listStyle: "none",
        textAlign: "center",
        justifyContent: "space-between",
        width: "80%",
    },

    [theme.breakpoints.up("lg")]: {
        display: "flex",
        alignItems: "center",
        listStyle: "none",
        textAlign: "center",
        justifyContent: "space-between",
        width: "40%",
    },
}))

export const NavItem = styled('li')(({ theme }) => ({
    fontSize: "16px",
    fontWeight: 400,
    lineHeight: "20px",
    letterSpacing: 1.5,
    padding: "10px",
    textTransform: "uppercase",

    ":hover": {
        color: theme.palette.primary.main,
    },
}))

export const NavLinks = styled(LinkScroll)(({ theme }) => ({
    textDecoration: "none",
    color: theme.palette.secondary.light,
    cursor: "pointer",
}))


export const SidebarContainer = styled('div')<{ isOpen: boolean }>(({ theme, isOpen }) => ({
    position: "fixed",
    zIndex: 999,
    width: "100%",
    height: `${isOpen ? '100%' : '0%'}`,
    backgroundColor: "#FFF",
    display: "grid",
    alignItems: "start",
    top: `${isOpen ? '70px' : '-100%'}`,
    right: "0",
    transition: "0.3s ease-in-out",
    opacity: `${isOpen ? '100%' : '0'}`,

    [theme.breakpoints.up("md")]: {
        display: "none",
    },
}))

export const SidebarWrapper = styled.div(({ theme }) => ({
    color: "#000000",
}))

export const SidebarMenu = styled.ul`
  display: grid;
  grid-template-columns: 1fr;
  grid-template-rows: repeat(5, 80px);
  text-align: left;
`

export const SidebarLink = styled(LinkScroll)(({ theme }) => ({
    fontSize: "16px",
    fontWeight: 400,
    display: "flex",
    alignItems: "center",
    justifyContent: "start",
    padding: "0px 30px",
    borderBottom: "1px solid #dedede",
    textTransform: "uppercase",
    textDecoration: "none",
    listStyle: "none",
    transition: "0.2s ease-in-out",
    color: theme.palette.secondary.dark,
    cursor: "pointer",

    ":hover": {
        color: theme.palette.primary.main,
        transition: "0.2s ease-in-out",
    },
}))

export const SideBtnWrap = styled.div`
    display: flex;
    justify-content: center;
`
