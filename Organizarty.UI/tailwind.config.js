/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Pages/**/*.cshtml",
    "./Blazor/**/*.razor",
    "./Organizarty.UI/Pages/**/*.cshtml",
    "./Organizarty.UI/Blazor/**/*.cshtml",
    "./node_modules/flowbite/**/*.{js,razor,html,cshtml}"
  ],
  theme: {
    extend: {},
  },
  plugins: [
    require('flowbite/plugin')
  ],
}
