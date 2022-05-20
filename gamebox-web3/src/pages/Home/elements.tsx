import styled from "styled-components";
import { StyledText } from "../../components/Text";

export const TitleSmallText = styled('span')(({ theme }) => ({
    color: theme.palette.secondary.light,
    fontSize: "22px",
    margin: "10px 0",
    textAlign: "center",

    [theme.breakpoints.down("md")]: {
        fontSize: "20px",
    },
}))

export const HomeImg = styled('img')(({ theme }) => ({
    width: "80%",
    margin: "20px 0",

    [theme.breakpoints.down("md")]: {
        width: "100%",
    },
}))

export const MapImg = styled(HomeImg)(({ theme }) => ({
    width: "60%",
    margin: "20px 0",

    [theme.breakpoints.between("md", "lg")]: {
        width: "100%",
    },

    [theme.breakpoints.down("md")]: {
        width: "100%",
    },
}))

export const DescriptionText = styled(StyledText)(({ theme }) => ({
    fontSize: "20px",
    textAlign: "center",
    width: "80%",

    [theme.breakpoints.down("md")]: {
        fontSize: "18px",
        width: "100%",
    },
}))

export const OverviewImg = styled('img')(({ theme }) => ({
  width: '80%',
  margin: '20px 0',

  [theme.breakpoints.down('md')]: {
    width: '100%'
  }
}))

export const SloganImg = styled('img')(({ theme }) => ({
  width: '50%',
  margin: '10px 0',

  [theme.breakpoints.between('md', 'lg')]: {
    width: '70%'
  },

  [theme.breakpoints.down('md')]: {
    width: '100%'
  }
}))

export const IconImg = styled('img')(({ theme }) => ({
  width: '100px',
  height: '100px',
  marginBottom: '20px'
}))