import React from "react"
import navLinks from "../../config/menus";
import {
    SidebarContainer,
    SidebarWrapper,
    SidebarLink,
    SidebarMenu,
} from './elements';

interface SidebarProps {
    isOpen: boolean,
    toggle: () => void,
}

const Sidebar: React.FC<SidebarProps> = ({ isOpen, toggle }) => {
    return (
        <SidebarContainer isOpen={isOpen} onClick={toggle}>
            <SidebarWrapper>
                <SidebarMenu>
                    {
                        navLinks.map(item => (
                            <SidebarLink
                                to={item.link}
                                key={item.name}
                                spy={true}
                                smooth={true}
                                offset={-70}
                                onClick={toggle}
                            >{item.name}</SidebarLink>
                        ))
                    }
                </SidebarMenu>
            </SidebarWrapper>
        </SidebarContainer>
    )
}

export default Sidebar