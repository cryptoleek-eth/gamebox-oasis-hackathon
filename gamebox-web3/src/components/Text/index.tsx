import styled from "styled-components";

export const StyledH2 = styled('h2')<{ isUpperCase?: boolean }>(({ theme, isUpperCase }) => ({
    color: theme.palette.primary.main,
    margin: "20px 0",
    textTransform: `${isUpperCase ? 'uppercase' : 'none'}`,
    fontSize: "42px",
    textAlign: "center",

    [theme.breakpoints.down("md")]: {
        fontSize: "30px",
        margin: "10px 0",
    },
}))

export const StyledH3 = styled('h3')<{ isDark?: boolean, isUpperCase?: boolean }>(({ theme, isDark, isUpperCase }) => ({
    color: `${isDark ? theme.palette.secondary.main : theme.palette.primary.main}`,
    fontSize: "26px",
    margin: "10px 0",
    textTransform: `${isUpperCase ? 'uppercase' : 'none'}`,
    textAlign: "center",

    [theme.breakpoints.down("md")]: {
        fontSize: "22px"
    },
}))

export const StyledH4 = styled('h4')(({ theme }) => ({
    color: theme.palette.secondary.light,
    fontSize: "22px",
    marginBottom: "20px",

    [theme.breakpoints.down("md")]: {
        textAlign: "center",
        fontSize: "20px",
    },
}))

export const StyledText = styled('p')(({ theme }) => ({
    lineHeight: "28px",
    fontSize: "16px",
    textAlign: "left",
    marginBottom: "20px",
    color: theme.palette.secondary.light,

    [theme.breakpoints.down("md")]: {
        textAlign: "center"
    },
}))

export const StyledIntro = styled('li')(({ theme }) => ({
    color: theme.palette.secondary.light,
    lineHeight: "28px",
    margin: "5px 0",
    fontSize: "16px"
}))