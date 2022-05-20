import React from "react";
import { Box } from "@mui/material";
import { StyledH4, StyledText } from "../../components/Text"
import { StyledTextLink } from "../LinkExternal";
import { Wrapper, WidthWrapper } from "../Layout";
import { Grid } from "@mui/material";
import { FooterLink, FooterCopyright } from "./elements";
import navLinks from "../../config/menus";
import { FaTwitter, FaDiscord, FaTelegram, FaYoutube } from "react-icons/fa"

const Footer: React.FC = () => {
  return (
    <Wrapper style={{ backgroundColor: '#242021', marginBottom: '0px' }}>
      <WidthWrapper>
        <Grid container spacing={3}>
          <Grid container item sm={12} md={3} alignItems="start" justifyContent="center">
            <Box
              sx={{
                display: 'flex',
                flexDirection: 'column'
              }}>
              <StyledH4>Socials:</StyledH4>
              <Box sx={{
                display: "flex",
                width: "100%",
                alignItems: "center",
                justifyContent: "space-between"
              }}>
                <StyledTextLink href="#" target="_blank">
                  <FaTwitter style={{ width: "24px", height: "24px" }} />
                </StyledTextLink>
                <StyledTextLink href="#" target="_blank">
                  <FaYoutube style={{ width: "24px", height: "24px" }} />
                </StyledTextLink>
              </Box>

              <Box sx={{
                display: "flex",
                width: "100%",
                alignItems: "center",
                justifyContent: "space-between"
              }}>
                <StyledTextLink href="#" target="_blank">
                  <FaDiscord style={{ width: "24px", height: "24px" }} />
                </StyledTextLink>
                <StyledTextLink href="#" target="_blank">
                  <FaTelegram style={{ width: "24px", height: "24px" }} />
                </StyledTextLink>
              </Box>
            </Box>
          </Grid>

          <Grid container item sm={12} md={3} alignItems="start" justifyContent="center">
            <Box
              sx={{
                display: 'flex',
                flexDirection: 'column'
              }}>
              <StyledH4>Navigations:</StyledH4>

              {navLinks.map((item) => (
                <FooterLink
                  to={item.link}
                  key={item.name}
                  spy={true}
                  smooth={true}
                  offset={-70}
                >
                  {item.name}
                </FooterLink>
              ))}
            </Box>
          </Grid>

          <Grid container item sm={12} md={3} alignItems="start" justifyContent="center">
            <Box
              sx={{
                display: 'flex',
                flexDirection: 'column'
              }}>
              <StyledH4>Medias:</StyledH4>
              <StyledText>Game Box web3 gaming solution and platform.</StyledText>
              <StyledText></StyledText>
            </Box>
          </Grid>

          <Grid container item sm={12} md={3} alignItems="start" justifyContent="center">
            <Box
              sx={{
                display: 'flex',
                flexDirection: 'column'
              }}>
              <StyledH4>About:</StyledH4>
              <StyledText>We are a group of passionate Web3 builders and metaverse gamers. Our vision is the future game will be established on the real economy providing competitve, incentivised and fun experience to everyone. We are calling all the gamers out there to join our platform today and experience tomorrow.</StyledText>
            </Box>
          </Grid>
        </Grid>

        <FooterCopyright>Built By GameBox Team</FooterCopyright>
      </WidthWrapper>
    </Wrapper>
  )
}

export default Footer