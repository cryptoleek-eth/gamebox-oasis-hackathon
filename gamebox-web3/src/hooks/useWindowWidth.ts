import { useState, useEffect, useCallback } from "react"

export const useWindowWidth = (width: number) => {
    const widthState = window.innerWidth >= width ? true : false
    const [isVisible, setIsVisible] = useState<boolean>(widthState)

    const updateWindowWidth = useCallback(() => {
        if (window.innerWidth >= width) {
            setIsVisible(true)
        } else {
            setIsVisible(false)
        }
    }, [width])

    useEffect(() => {
        window.addEventListener('resize', updateWindowWidth)
        return () => {
            window.removeEventListener('resize', updateWindowWidth)
        }
    }, [updateWindowWidth])

    return isVisible
}