<script>
	import stopIcon from "$lib/assets/stop-palm-svgrepo-com.svg"
	async function addCigarette() {
		try {
			const res = await fetch("http://localhost:5150/api/logs", {
				method: "POST"
			});

			const data = await res.json();
			console.log(data);
			close();
		} catch (error) {
			console.error(error);
		}
	}

	let dialog;

	export function open() {
		dialog.style.display = "flex";
		dialog.showModal();
	}

	function close() {
		dialog.style.display = "none"
		dialog.close();
	}
</script>

<dialog bind:this={dialog}>
	<h2>Do you really want to smoke that?</h2>
	<div class="logo-container">
		<img class="logo" src={stopIcon} alt="" srcset="">
	</div>
	
	<button class="confirm-btn" onclick={addCigarette}>Yes</button>
	<button class="cancel-btn" onclick={() => close()}>No</button>
</dialog>

<style>
	img {
		filter: invert(0);
	}

	dialog {
		border: none;
		display: none;
		flex-direction: column;
		gap: 1rem;
		align-items: center;
	}

	.confirm-btn {
		background: linear-gradient(180deg, #ff0000, rgb(143, 0, 0));
		color: white;
	}

	.cancel-btn {
		background-color: green;
		color: white;
		background: linear-gradient(180deg, #6f8000, #003600);
	}

	button {
		font-size: large;
		border: none;
		padding: 1rem 2rem;
		border-radius: 5px;
		width: 100%
	}

	h2 {
		text-align: center;
	}
</style>
