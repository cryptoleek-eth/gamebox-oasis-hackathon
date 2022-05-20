import React, { useState, useCallback } from "react";
import { StyledAppBar, StyledToolbar, ImgContainer, StyledLogo, NavMenu, NavItem, NavLinks } from "./elements"
import navLinks from "../../config/menus";
import { StyledIconButton } from "../Button";
import { HiMenuAlt4 } from "react-icons/hi"
import { FaTimes } from 'react-icons/fa';
import Sidebar from "./Sidebar";

const NavBar: React.FC = () => {
    const [isOpen, setIsOpen] = useState(false);

    const toggle = useCallback(() => {
        setIsOpen(!isOpen);
    }, [isOpen]);

    return (
        <>
            <StyledAppBar>
                <StyledToolbar>
                    <ImgContainer to="/">
                        <StyledLogo src="./images/logo.png"></StyledLogo>
                    </ImgContainer>

                    <NavMenu>
                        {
                            navLinks.map(item => (
                                <NavLinks
                                    key={item.name}
                                    to={item.link}
                                    spy={true}
                                    smooth={true}
                                    offset={-70}
                                >
                                    <NavItem>{item.name}</NavItem>
                                </NavLinks>
                            ))
                        }
                    </NavMenu>

                    {
                        !isOpen ? <StyledIconButton size="large" onClick={toggle}>
                            <HiMenuAlt4 />
                        </StyledIconButton> : <StyledIconButton size="large" onClick={toggle}>
                            <FaTimes />
                        </StyledIconButton>
                    }
                </StyledToolbar>
            </StyledAppBar>

            <Sidebar isOpen={isOpen} toggle={toggle} />
        </>


    )
}

export default NavBar