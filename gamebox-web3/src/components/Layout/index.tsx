import styled from "styled-components"

export const Wrapper = styled('div')(({ theme }) => ({
    padding: "30px 20px",
    marginTop: "120px",
    marginBottom: "20px",

    [theme.breakpoints.down("md")]: {
        marginTop: "100px",
        padding: "20px 10px",
    },
}))

export const WidthWrapper = styled('div')(({ theme }) => ({
    width: "80%",
    display: "block",
    margin: "0 auto",

    [theme.breakpoints.down("md")]: {
        width: "90%"
    },
}))

export const BannerContainer = styled('div')<{ isOverview?: boolean }>(({ theme, isOverview }) => ({
    backgroundImage: `${isOverview ? 'url(./images/overview/banner.jpeg)' : 'url(./images/features/banner.jpeg)'}`,
    height: "40vh",
    marginTop: "70px",
    backgroundRepeat: "no-repeat",
    backgroundPosition: "center",
    backgroundSize: "cover",
    opacity: 0.5,

    [theme.breakpoints.between("md", "lg")]: {
        marginTop: "100px",
    },

    [theme.breakpoints.down("md")]: {
        height: "30vh",
    },
}))