import { ThemeProvider } from '@mui/material'
import theme from './theme'

const Providers: React.FC = ({ children }) => {
    return (
        <ThemeProvider theme={theme}>
            {children}
        </ThemeProvider>
    )
}

export default Providers