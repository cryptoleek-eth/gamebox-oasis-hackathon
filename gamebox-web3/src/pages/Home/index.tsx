import React, { useMemo } from "react";
import { Wrapper, WidthWrapper } from "../../components/Layout";
import { Box } from "@mui/material";
import contents from "../../locales/contents.json"
import { StyledH2, StyledH3, StyledIntro } from '../../components/Text'
import { TitleSmallText, HomeImg, DescriptionText, MapImg } from "./elements";
import { IconImg } from './elements'
import { StyledButton } from "../../components/Button";
import { isMobile } from "react-device-detect"
import games from "../../config/games";
import { Grid } from '@mui/material'

const Home: React.FC = () => {
  const homeContents = useMemo(() => {
    return contents.home
  }, [])

  const overviewContents = useMemo(() => {
    return contents.overview
  }, [])

  const playGames = (webLink: string, mobileLink: string) => {
    isMobile ? window.open(mobileLink, '_blank') : window.open(webLink, '_blank')
  }

  return (
    <Wrapper>
      <WidthWrapper>
        <Box>
          <Box sx={{
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
            justifyContent: 'center',
          }} id="home">
            <TitleSmallText>{homeContents.titleSmall}</TitleSmallText>

            <StyledH2 isUpperCase={true}>{homeContents.titleBig}</StyledH2>

            <StyledH3 isDark={true}>{homeContents.slogan}</StyledH3>

            <HomeImg src="./images/home/home.png"></HomeImg>

            <DescriptionText>{homeContents.description}</DescriptionText>
          </Box>


          <Box id="demo">
            <StyledH2>Game Demo</StyledH2>
            {
              games.map(game => (
                <Box
                  key={game.name}
                  sx={{
                    margin: "20px 0"
                  }}
                >
                  <Grid container spacing={6}>

                    <Grid container item sm={12} md={2} alignItems="center" justifyContent="center">
                      <Box sx={{
                        display: 'flex',
                        flexDirection: 'column',
                        alignItems: 'center',
                        justifyContent: 'center',
                      }}>
                        <StyledH3 style={{ margin: "20px 0" }}>{game.name}</StyledH3>
                        <StyledButton onClick={() => playGames(game.webLink, game.mobileLink)}>Play Games</StyledButton>
                      </Box>
                    </Grid>

                    <Grid container item sm={12} md={5} alignItems="start" justifyContent="center">
                      <iframe width="560" height="315" src={game.webVideoLink} title="Web3 game Flappy Bird on mobile now. Amazing." />
                    </Grid>

                    {
                      game.mobileVideoLink && <Grid container item sm={12} md={5} alignItems="start" justifyContent="center">
                        <iframe width="560" height="315" src={game.mobileVideoLink} title="Web3 game Flappy Bird on mobile now. Amazing." />
                      </Grid>
                    }
                  </Grid>
                </Box>
              ))
            }
          </Box>

          <Box id="features">
            <StyledH2>Features</StyledH2>
            <Box
              sx={{
                backgroundColor: 'rgba(10,11,13,0.3)'
              }}>
              <Grid container spacing={3} sx={{ marginTop: '5px' }}>
                {overviewContents.descs.map((item, index) => (
                  <Grid container item sm={12} md={6} lg={6} xl={3} alignItems="start" justifyContent="center" key={index}>
                    <Box
                      sx={{
                        display: 'flex',
                        flexDirection: 'column',
                        padding: '20px'
                      }}>
                      <Box
                        sx={{
                          display: 'block',
                          margin: '0 auto'
                        }}>
                        <IconImg
                          src={`./images/overview/${item.catergory}.png`}
                          loading="lazy"></IconImg>
                      </Box>

                      <StyledH3>{item.title}</StyledH3>

                      {item.intros.map((intro) => (
                        <StyledIntro key={intro}>{intro}</StyledIntro>
                      ))}
                    </Box>
                  </Grid>
                ))}
              </Grid>
            </Box>
          </Box>

          <Box sx={{
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
            justifyContent: 'center',
          }} id="community">
            <StyledH2 isUpperCase={true}>Global Community</StyledH2>
            <MapImg src="./images/home/map.png"></MapImg>
          </Box>
        </Box >
      </WidthWrapper>
    </Wrapper >

  )
}

export default Home