/** @type {import('tailwindcss').Config} */

module.exports = {
  content: [
    './src/**/*.{js,ts,jsx,tsx}',
  ],

  theme: {
    extend: {
      colors: {
        primary: '#041643',
        secondary: '#1352F1',
        denied: '#EF4444',
        success: '#10B981',
      },
      fontFamily: {
        sans: ['Inter', 'sans-serif'],
        heading: ['Poppins', 'sans-serif'],
        alexandria: ["var(--font-alexandria)", "sans-serif"],
      },
      backgroundLoginImage: {

      }
    },
  },
  plugins: [],
}
