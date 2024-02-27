import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  server:{
    port: 3000,
    proxy: {
      '/products': {
        target: 'http://localhost:5000',
        changeOrigin: true,
        rewrite: (path) => path.replace(/^\/products/, ''),
        secure: false,
        ws: true,
        configure(proxy, options) {
            proxy.on('error', (err, req, res) => {
              console.log('proxy error', err);
            });
            proxy.on('proxyReq', (proxyReq, req, res) => {
              console.log('proxy Request to target: ', proxyReq, req.method, req.url);
            });
            proxy.on('proxyRes', (proxyRes, req, res) => {
              console.log('proxy Respose from target', proxyRes);
            });
        },
      }
    }
  }
})
