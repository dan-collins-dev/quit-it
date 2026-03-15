<script>
	import iconSrc from "$lib/assets/logo-no-smoking.svg";
	import { page } from "$app/stores";

	// let pageName = $state("");
	let currentPageName = $derived($page.url.pathname.split("/").filter(Boolean).pop() || "Home");

	function capitalizeFirstLetter(name) {
		if (name.length === 0) {
			return name;
		}
		return name.charAt(0).toUpperCase() + name.slice(1);
	}
</script>

<header class="header">
	<div class="logo-container">
		<img class="logo" src={iconSrc} alt="" />
	</div>
	<h1>Quit It</h1>
	<p>{capitalizeFirstLetter(currentPageName)}</p>
</header>

<style>
	p {
		margin-left: auto;
		font-size: xx-large;
	}
</style>
